/// <reference path="../libs/underscore.js" />

function PostsController($scope, $http) {
	$scope.newPost = {
		Title: "",
		Content: "",
		CategoryName: ""
	};

	console.log("Sending request...");
    $http.get("http://localhost:23226/api/posts")
	.success(function (posts) {
	    console.log(posts);
		$scope.posts = posts;
		$scope.categories = _.uniq(_.pluck(posts, "Category"));
		$scope.selectedCategory = $scope.categories[0];
	});

	$scope.addPost = function () {
		
		//var category = $scope.newPost.category;
		//if (!_.contains($scope.categories, category)) {
		//	$scope.categories.push(category);
		//}
	    var postDetails = {
	        Title: $scope.newPost.Title,
	        Content: $scope.newPost.Content,
	        Category: {
	            Name: $scope.newPost.CategoryName
	        }
	    };


	    $http.post("http://localhost:23226/api/posts", postDetails)
	    .success(function (resultPost) {
	        if (resultPost) {
	            $scope.posts.push(resultPost);

	            $scope.newPost = {
	                Title: "",
	                Content: "",
	                CategoryName: ""
	            };
	        }
	    });
	}
}

function SinglePostController($scope, $http, $routeParams) {
	var id = $routeParams.id;
    $http.get("http://localhost:23226/api/posts?postId=" + id)
	.success(function (post) {
		//var post = _.first(_.where(posts, { "id": parseInt(id) }));
		//debugger;
		$scope.post = post;
	})
}

function CategoryController($scope, $http, $routeParams) {
    var categoryId = $routeParams.categoryId;
    console.log("Categories");
    $http.get("http://localhost:23226/api/categories?categoryId=" + categoryId)
	.success(function (category) {
		//var category = {
		//	name: categoryName,
		//	posts: []
		//};
		//_.chain(posts)
		//.where({ "category": categoryName })
		//.each(function (post) {
		//	category.posts.push({
		//		id: post.id,
		//		title: post.title,
		//		content: post.content
		//	});
		//})
		$scope.category = category;
	})
};