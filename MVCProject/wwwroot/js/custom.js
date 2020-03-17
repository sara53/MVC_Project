$("document").ready(function () {

    $('.new_Btn').bind("click", function () {
        $('#html_btn').click();
    });

    $(".btn-Post").click(function () {



        var _postText = $("#createPostArea").val();

        var today = new Date();

        var dd = String(today.getDate()).padStart(2, '0');
        var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
        var yyyy = today.getFullYear();

        today = mm + '/' + dd + '/' + yyyy;

        if (_postText != "") {
            $.ajax({
                type: "POST",
                url: "Home/Create",
                data: {
                    "PostDateTime": today,
                    "PostContent": _postText,
                    "UserId": 2,
                    "IsDeleted": false
                },
                
                dataType: "text",
                success: function (msg) {


                    console.log(_postText);


                    $(".PostText").text(_postText);
                    $(".displayAcreation").css("display", "block");
                    console.log("here " + $("#html_btn").val());
                    



                },
                error: function (req, status, error) {
                    alert("Error Happen " + error);



                }
            });

        }

    });
});


