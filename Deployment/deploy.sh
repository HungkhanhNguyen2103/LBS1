# ireading_api
docker build -t ireading_api -f Dockerfile.IReadingAPI ..
# ireading_web
docker build -t ireading_web -f Dockerfile.IReadingWeb ..

docker-compose -f docker-compose.yml down
docker-compose build
docker-compose -f docker-compose.yml up -d
# docker system prune -a -f