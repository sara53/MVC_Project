$("document").ready(function () {

    $('.new_Btn').bind("click", function () {
        $('#html_btn').click();
    });

    //PostButton --- Publish Post
    $(".btn-Post").click(function () {

        var _postText = $("#createPostArea").val();

        //var today = new Date();

        //var dd = String(today.getDate()).padStart(2, '0');
        //var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
        //var yyyy = today.getFullYear();

        //today = mm + '/' + dd + '/' + yyyy;

        if (_postText != "") {
            $.ajax({
                type: "POST",
                url: "Home/Create",
                data: {
                    //"PostDateTime": today,
                    "PostContent": _postText,
                    "UserId": 2,
                    "IsDeleted": false
                },

                dataType: "text",
                success: function (msg) {


                    console.log(_postText);


                   
                    $("#createPostArea").val("");
                    $(' <div class="createPost2"><img src ="../img/prof.png" alt = "" class= "PrfilePic" ><span class="ProfileName">Sara Atef</span> <br><span class="PostTime">now</span> <i class="fas fa-users"></i><Select><option value=""></option><option value="" class="RemovePost">Remove Post</option></Select><p class="PostText"></p><div class="react"><span class="Like" data-id="@item.PostId"><i class="far fa-thumbs-up"></i><span class="LikeWord">Like</span></span><span class="Comment"><i class="far fa-comments"></i><span>Comment</span></span></div><hr><div class="comments"><div class="pComment"><div class="CommingComment"><img src="../img/prof.png" alt="" class="commentPic"><textarea name="" id="areaOfComment" placeholder="Type Your Comment Here" class="typeComment" data-id="@item.PostId"></textarea></div></div></div></div>').insertAfter('.createPost');
                    //$(".displayAcreation").css("display", "block");
                    console.log("here " + $("#html_btn").val());
                    $(".PostText").text(_postText);




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

    $(".Like").click(function () {

        var _that = $(this);
        var _postID = $(this).attr('data-id');

            $.ajax({
                type: "POST",
                url: "Home/Like",
                data: {
                    "PostId": _postID,
                    "IsLiked": true,
                    "UserId": 2,
                 
                },

                dataType: "text",
                success: function (msg) {

                    var color = _that.children().css("color");
                    
                    if (color == "rgb(0, 0, 0)") {
                        color = "rgb(0,0,1)";
                        console.log("inside if");
                       
                        _that.children().css("color", "blue");



                    } else {
                        color = "rgb(0, 0, 0)";

                        _that.children().css("color", "black");
                       
                    }

                    

                },
                error: function (req, status, error) {
                    alert("Error Happen " + error);

                }
        });
       

     
    });

    //if (localStorage.getItem('LikeColor')) {
    //    console.log(localStorage.getItem('LikeColor'));
    //    var _StoredColor = localStorage.getItem('LikeColor');
    //    $(".Like").children().css("color", _StoredColor);
    //    console.log("done");
    //}


});



