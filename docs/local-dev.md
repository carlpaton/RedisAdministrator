# Local development

Testing [DockerFile](DockerFile) works and the image can be built.

```bash
docker build -t redis-admin-test-image -f Dockerfile .
docker images
docker rmi redis-admin-test-image
```