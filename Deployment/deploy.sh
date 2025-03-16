# ireading_api
docker build -t ireading_api -f Dockerfile.IREADINGAPI ..
# ireading_web
docker build -t ireading_web -f Dockerfile.IREADINGWEB ..

docker-compose -f docker-compose.yml down
docker-compose build
docker-compose -f docker-compose.yml up -d
# docker system prune -a -f