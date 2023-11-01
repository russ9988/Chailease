
# 練習利用Volume Mount到Host

1. 輸入以下指令

``` powershell
cd ..\frontend-ui\

docker run -d --rm                                                         `
            --name frontend-ui-demo2-1-container                           `
            -p 4200:4200                                                   `
            -v D:\AD\Project\docker101\frontend-ui\src:/app/src  `
            frontend-ui-demo2
```

2. 將Angular網站跑起來後，可以透過localhost:4200連線上容器中的Angular網站。
3. 透過調整D:\AD\Project\docker101\frontend-ui\src\app\app.component.html裡面的文字顯示，查看是否有同步變化

# 練習利用Volume到Docker

1. 如同demo2，輸入以下指令

``` powershell
    docker run -d --rm --name frontend-ui-demo2-container `
                -p 4200:4200                              `
                -v frontend-ui-volume-container:/app/src      `
                frontend-ui-demo2 
```

# 將Volume中的資料，複製到Host

- 建立臨時容器：使用臨時容器可以很容易地從卷中複製資料。
- 執行以下命令建立包含Volume的Angular容器，其中包括要複製的卷(Volume)：

    ``` powershell
    $hostDataPath = "D:\AD\Project\docker101\demo2-1\Volume-data"
    docker run -it --rm -v frontend-ui-Volume-in-Docker:/volume-data -v D:\AD\Project\docker101\demo2-1\Volume-data:/host-data alpine
    ```

輸入以下指令，建立臨時alpine容器，並且掛載要複製的卷(Volume)

``` powershell
docker run -it --rm -v <卷名稱>:/volume-data -v $(pwd):/host-data alpine
```

> <卷名稱>：將其替換為要複製的卷的名稱。
> /volume-data：容器內的路徑，用於卷資料。
> /host-data：主機上的路徑，您將在這裡找到複製的資料。
> alpine：用於臨時容器的 Docker 映像。

- 複製資料：進入臨時容器後，您可以使用 cp 或其他命令從容器的 /volume-data 路徑複製資料到 /host-data，然後退出容器。
- 輸入以下指令，複製卷資料到host-data，以達成將Volume的資料複製到Host主機上

    ``` powershell
    cp -r /volume-data/* /host-data/
    ```

- 複製完成，再輸入以下指令結束即可

    ``` powershell
    exit
    ```
