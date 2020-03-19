$("document").ready(function () {

    $('.new_Btn').bind("click", function () {
        $('#html_btn').click();
    });

    //PostButton --- Publish Post
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
                    $("#createPostArea").val(" ");
                    $(".displayAcreation").css("display", "block");
                    console.log("here " + $("#html_btn").val());




                },
                error: function (req, status, error) {
                    alert("Error Happen " + error);



                }
            });

        }


    });

  
 
   //Post A comment
    $('.typeComment').keydown(function (e) {
        if (e.keyCode == 13) {

            var _commentText = $("#areaOfComment").val();

            var today = new Date();

            var dd = String(today.getDate()).padStart(2, '0');
            var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
            var yyyy = today.getFullYear();

            today = mm + '/' + dd + '/' + yyyy;

     
           var _PostID = $(this).attr('data-id');
            var _that = $(this);
            console.log(_that.parent());


            if (_commentText != "") {
                $.ajax({
                    type: "POST",
                    url: "Home/AddComment",
                    data: {
                        "CommentDateTime": today,
                        "CommentContent": _commentText,
                        "UserId": 2,
                        "IsDeleted": false,
                        "PostId": _PostID
                    },

                    dataType: "text",
                    success: function (msg) {


                        console.log(_commentText);

                       

                
                        $('.typeComment').val(" ");
                        var _insertVarElement= _that.parent().parent()
                        $('<div class="commented"><img src = "../img/prof.png" alt = "" class= "commentPic" ><p class="commenttext"><span class="CommentedName">Sara Atef</span><br><span><span><Select class="RemoveComment"><option value=""></option><option value="">Remove Comment</option></Select><span class="CommentText"></span> </p></div>').insertAfter(_insertVarElement);
                        $(".CommentText").text(_commentText);
                    },
                    error: function (req, status, error) {
                        alert("Error Happen " + error);



                    }
                });

            }




        }
    });

    //$.ajax({
    //    type: "POST",
    //    url: "Home/AddComment",
    //    data: {
    //        "CommentDateTime": today,
    //        "CommentContent": _commentText,
    //        "UserId": 2,
    //        "IsDeleted": false,
    //        "PostId": _PostID
    //    },

    //    dataType: "text",
    //    success: function (msg) {


    //        console.log(_commentText);




    //        $('.typeComment').val(" ");
    //        var _insertVarElement = _that.parent().parent()
    //        $('<div class="commented"><img src = "../img/prof.png" alt = "" class= "commentPic" ><p class="commenttext"><span class="CommentedName">Sara Atef</span><br><span><span><Select class="RemoveComment"><option value=""></option><option value="">Remove Comment</option></Select><span class="CommentText"></span> </p></div>').insertAfter(_insertVarElement);
    //        $(".CommentText").text(_commentText);
    //    },
    //    error: function (req, status, error) {
    //        alert("Error Happen " + error);



    //    }
    //});

});



