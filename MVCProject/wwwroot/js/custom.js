$("document").ready(function () {

    $('.new_Btn').bind("click", function () {
        $('#html_btn').click();
    });

    $(".btn-Post").click(function () {


        val1 = "5";
        val2 = "2";

        var _postText = $("#createPostArea").val();
        if (_postText != "") {
            $.ajax({
                type: "POST",
                url: "Home/Add",
                data: { number1: val1, number2: val2 },
                dataType: "text",
                success: function (msg) {


                    console.log(_postText);


                    $(".PostText").text(_postText);
                    $(".displayAcreation").css("display", "block");
                    console.log("here " + $("#html_btn").val());



                },
                error: function (req, status, error) {
                    alert(error);



                }
            });

        }

    });
});


