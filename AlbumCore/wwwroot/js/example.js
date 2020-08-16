

let i = 1;
var infScroll = new InfiniteScroll(".example", {
    path: function () {
        // 頁面路徑
        if (this.loadCount < 1) {


            console.log(i + '  ' + this.loadCount)
            var someStringValue = @safeStringValue;
            console.log(someStringValue)
            i++;
            return "https://output.jsbin.com/cuqowif"; // 讀取此頁面
        }
    },
    append: ".article", // 匯入物件類別
    status: ".scroller-status" // 捲軸狀態類別
})


