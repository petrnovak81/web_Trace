<span id="notification"></span>
<script>
    var notification;
    $(function () {
        notification = $("#notification").kendoNotification().data("kendoNotification");
    });
    function message(msg, type, ms) {
        setTimeout(function () {
            if (type === undefined) { type = "info" };
            if (ms === undefined) { ms = 5000 };
            notification.setOptions({
                autoHideAfter: ms,
                position: {
                    top: 20,
                    bottom: null,
                    right: 20,
                    left: null,
                },
                stacking: "down"
            });
            notification.show(msg, type);
        }, 100);
    };
</script>