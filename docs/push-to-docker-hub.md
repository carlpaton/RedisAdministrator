```bash
docker build -t carlpaton/redis-administrator:test .

docker run --name red-admin-test -d -p 8088:80 carlpaton/redis-administrator:test

docker push carlpaton/redis-administrator:test
```