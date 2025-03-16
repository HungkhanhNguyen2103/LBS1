# lweys_api
docker build -t lweys_api -f Dockerfile.LWEYSAPI ..
# lweys
docker build -t lweys -f Dockerfile.LWEYS ..

docker-compose -f docker-compose.yml down
docker-compose build
docker-compose -f docker-compose.yml up -d
# docker system prune -a -f