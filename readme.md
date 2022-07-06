# Sample Docker and Kubernetes Projects

This is just sample code in various states of usefullness; a place to test different project types, building docker images, docker containers and kubernetes deployments using docker desktop with kubernetes. The ingress examples require ingress-nginx to be installed and configured.

Most of the samples expect images pulled from a local docker registry: http://localhost:5000.

```pwsh
cd src/$PROJECT-NAME
docker-compose build
kubectl apply -f *.yaml # or the specific specification in that folder
```
