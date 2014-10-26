/// <reference path="../libs/_references.js" />
window.viewModels = (function () {
    var data = null;

    function setData(inputData) {
        data = inputData;
    }

    function getLoginViewModel(callback) {
        var viewModel = new kendo.observable({
            username: "",
            nickname: "",
            password: "",
            errMessage: "",
            login: function () {
                var self = this;

                data.users.login(this.get("username"), this.get("password"))
                    .then(function () {
                        if (callback) {
                            callback();
                        }

                        this.set("username", "");
                        this.set("nickname", "");
                        this.set("password", "");
                    }, function (err) {
                        var response = JSON.parse(err.responseText);
                        self.set("errMessage", response.Message);
                    });
            },
            register: function () {
                var self = this;

                data.users.register(this.get("username"), this.get("nickname"), this.get("password"))
                   .then(function () {
                       if (callback) {
                           callback();
                       }

                       this.set("username", "");
                       this.set("nickname", "");
                       this.set("password", "");
                   }, function (err) {
                       var response = JSON.parse(err.responseText);
                       self.set("errMessage", response.Message);
                   });
            }
        });

        return viewModel;
    }

    function getHomeViewModel(callback) {
        var viewModel = new kendo.observable({
            nickname: data.getNickname(),
            logout: function () {

                data.users.logout()
                    .then(function () {
                        if (callback) {
                            callback();
                        }
                    });
            }
        });

        return viewModel;
    }

    function getPostsViewModel(callback) {

        return data.posts.all()
            .then(function (posts) {

                return data.tags.all()
                     .then(function (tags) {
                         var viewModel = new kendo.observable({
                             posts: posts,
                             tags: tags,
                             searchTags: "",
                             postsMessage: function () {
                                 if (posts.length != 0) {
                                     return "";
                                 } else {
                                     return "There are no posts yet!";
                                 }
                             }(),
                             tagsMessage: function () {
                                 if (posts.length != 0) {
                                     return "";
                                 } else {
                                     return "No tags!";
                                 }
                             }(),
                             search: function () {
                                 var tags = this.get("searchTags");
                                 tags = tags.split(" ");

                                 if (callback) {
                                     callback(tags);
                                 }
                             }
                         });

                         return viewModel
                     });
            });
    }

    function getPostByIdViewModel(id) {
        return data.posts.getById(id)
           .then(function (post) {
               var viewModel = new kendo.observable({
                   post: post
               });

               return viewModel
           });
    }

    function getPostCommentViewModel(id, callback) {
        var viewModel = new kendo.observable({
            content: "",
            message: "",
            postComment: function () {
                var content = this.get("content");

                if (!content) {
                    this.set("message", "No content!");
                } else if (content.length <= 10) {
                    this.set("message", "Comment must be at least 11 characters!");
                } else {
                    var comment = {
                        content: content
                    };
                    data.posts.comment(id, comment)
                        .then(function () {
                            if (callback) {
                                callback();
                            }
                        });
                }
            },
        });

        return viewModel;
    }

    function getPostsByTagsViewModel(tags) {
        return data.posts.getByTags(tags)
            .then(function (posts) {
                var viewModel = new kendo.observable({
                    posts: posts,
                    tags: tags,
                    postMessage: function () {
                        if (posts.length != 0) {
                            return "";
                        } else {
                            return "No results!";
                        }
                    }(),
                });

                return viewModel;
            });
    }

    return {
        setData: setData,
        getLoginViewModel: getLoginViewModel,
        getHomeViewModel: getHomeViewModel,
        getPostsViewModel: getPostsViewModel,
        getPostByIdViewModel: getPostByIdViewModel,
        getPostCommentViewModel: getPostCommentViewModel,
        getPostsByTagsViewModel: getPostsByTagsViewModel
    }
}());