# Test using ingress resource
## To quickly test ingress,
```ps
kubectl port-forward --namespace=ingress-nginx service/ingress-nginx-controller 8080:80
```

```ps
start-process -filepath http://localdev.me:8080/
```

# Make sure to install Ingress support for docker desktop.

[Quick Start]( https://kubernetes.github.io/ingress-nginx/deploy/#quick-start )

```ps
kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.2.1/deploy/static/provider/cloud/deploy.yaml
```

## Pre-flight check
### A few pods should start in the ingress-nginx namespace
```ps
kubectl get pods --namespace=ingress-nginx
```

### Wait for the pods to be running
```ps
kubectl wait --namespace ingress-nginx \
  --for=condition=ready pod \
  --selector=app.kubernetes.io/component=controller \
  --timeout=120s
```

## Local test
Create a sample web server and associated service
```ps
kubectl create deployment demo --image=httpd --port=80
kubectl expose deployment demo
```

Create an ingress resource
```ps
kubectl create ingress demo-localhost --class=nginx --rule="demo.localdev.me/*=demo:80"
```

Forward a local port to the ingress controller
```ps
kubectl port-forward --namespace=ingress-nginx service/ingress-nginx-controller 8080:80
```

Test the endpoint
```ps
start-process -FilePath http://demo.localdev.me:8080/
```