
輸入以下指令，建置起RabbitMQ容器

``` powershell
docker run -d --name rabbitmq `
           -p 5672:5672 `
           -p 15672:15672 `
           --restart=always `
           --hostname rabbitmq-master `
           -v c:\docker\rabbitmq\data:/var/lib/rabbitmq `
           rabbitmq:latest
```
