```bash
docker build -t carlpaton/redis-administrator:develop .

docker run --name red-admin-develop -d -p 8088:80 carlpaton/redis-administrator:develop

docker push carlpaton/redis-administrator:develop
```