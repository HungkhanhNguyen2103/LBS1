const quill = new Quill('#ContentDiv', {
    theme: 'snow',
    modules: {
        toolbar: [
            [{ 'header': [1, 2, 3, false] }],
            ['bold', 'italic', 'strike'],
            [{ 'background': [] }],
            [{ 'script': 'sub' }, { 'script': 'super' }],
            [{ 'list': 'ordered' }, { 'list': 'bullet' }],
            [{ 'indent': '-1' }, { 'indent': '+1' }],
            [{ 'align': [] }],
            ['clean']
        ]
    }
});

const input1 = document.getElementById("ContentDiv");
const events = [
    "click", "focus", "blur", "change", "input",
    "keydown", "keyup", "keypress",
    "paste", "cut", "copy", "mousedown", "mouseup",
    "mouseenter", "mouseleave", "mouseover", "mouseout",
    "drag", "drop", "contextmenu"
];

events.forEach(event => {
    input1.addEventListener(event, (e) => {
        getWordNo();
    });
});

let timeout;
let backUpContent = "";
quill.on('text-change', function () {
    clearTimeout(timeout);
    timeout = setTimeout(() => {
        let content = input1.innerText;
        if (backUpContent != content) {
            backUpContent = content;
            checkChapterContentByAI(content);
        }
        //console.log(content);
    }, 5000);
});

function getWordNo() {
    // var delta = quill.getContents();
    // var text = JSON.stringify(delta);
    var textDiv = quill.getText().trim();
    var textContent = quill.root.innerHTML;
    $('#Content').val(textContent);
    var text = textDiv;
    let words = text.length > 0 ? text.split(/\s+/) : [];

    $('#wordNoCount').html(words.length);
    $('#WordNo').val(words.length);
}

function escapeRegExp(string) {
    return string.replace(/[.*+?^${}()|[\]\\]/g, '\\$&');
}

function highlightBadWordsPreserveFormat(words) {
    const text = quill.getText();
    const delta = quill.getContents();
    if (!words || words.length === 0) {
        quill.formatText(0, text.length, {
            color: false,
            underline: false
        }, 'user');
        return;
    }

    words.forEach(word => {
        let regex = new RegExp(`\\b(${escapeRegExp(word)})\\b`, 'gi');
        let match;

        while ((match = regex.exec(text)) !== null) {
            const startIndex = match.index;
            const length = match[0].length;

            quill.formatText(startIndex, length, {
                // background: 'yellow',
                color: 'red',
                underline: true
            }, 'user');
        }
    });
}


function changeFile(input) {
    const contentDeltaValue = {
        ops: [
            { insert: "" }
        ]
    };
    quill.setContents(contentDeltaValue);
    //document.getElementById("ContentDiv").innerText = "";
    if (input.files && input.files[0]) {
        let file = input.files[0];
        let typeName = file.type;
        if (typeName.includes('msword')) {
            notyf.error("Vui lòng chọn file .docx hợp lệ!");
            getWordNo();
            return;
        }
        if (typeName == "application/vnd.openxmlformats-officedocument.wordprocessingml.document") {
            const reader = new FileReader();

            reader.onload = function (event) {
                const arrayBuffer = event.target.result;

                mammoth.extractRawText({ arrayBuffer: arrayBuffer })
                    .then(result => {
                        const contentDelta = {
                            ops: [
                                { insert: result.value }
                            ]
                        };
                        quill.setContents(contentDelta);
                        //document.getElementById("ContentDiv").innerText = result.value;
                        getWordNo();
                    })
                    .catch(err => {
                        console.error("Lỗi đọc file:", err);
                        notyf.error("Không thể đọc file Word.");
                    });
            };

            reader.readAsArrayBuffer(file);
        }
        if (typeName == "text/plain") {
            //console.log("text");
            const reader = new FileReader();

            reader.onload = function (e) {
                const text = e.target.result;
                const contentDelta = {
                    ops: [
                        { insert: text }
                    ]
                };
                quill.setContents(contentDelta);
                //document.getElementById("ContentDiv").innerText = text;
                getWordNo();
            };

            reader.readAsText(file);
        }
        if (typeName == "application/pdf") {

            const reader = new FileReader();

            reader.onload = function () {
                const typedArray = new Uint8Array(reader.result);

                pdfjsLib.getDocument(typedArray).promise.then(async function (pdf) {
                    let textContent = '';

                    for (let pageNum = 1; pageNum <= pdf.numPages; pageNum++) {
                        const page = await pdf.getPage(pageNum);
                        const content = await page.getTextContent();
                        const strings = content.items.map(item => item.str).join(' ');
                        textContent += `Trang ${pageNum}:\n${strings}\n\n`;
                    }
                    const contentDelta = {
                        ops: [
                            { insert: textContent }
                        ]
                    };
                    quill.setContents(contentDelta);
                    //document.getElementById("ContentDiv").innerText = textContent;
                    getWordNo();
                });
            };

            reader.readAsArrayBuffer(file);
        }

    }
    let content = input1.innerText;
    checkChapterContentByAI(content);
    //getWordNo();
}
