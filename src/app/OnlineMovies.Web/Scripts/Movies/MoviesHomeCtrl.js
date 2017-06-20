
moviesAppModule.controller("MoviesHomeCtrl",
        function ($scope, moviesService) {
            moviesService.GetMoviesList().then(function (d) {
                    console.log(d.data);
                    $scope.moviesList = d.data;
                },
                function() {
                    alert('Failed');
                });
        })
    .factory("moviesService",
        function($http) {
            var fac = {}
            fac.GetMoviesList  = function() {
                return $http.get('/Movie/GetMoviesJsonResult');
            }
            return fac;
        });

moviesAppModule.controller("MovieReviewsCtrl",
    function ($scope, movieReviewsService) {
        var query = window.location.search.substring(4);
        console.log(query);
        
        movieReviewsService.GetMovieReviewsList(query).then(function (d) {
                console.log(d.data);
                $scope.movieReviewsList = d.data;
            },
            function () {
                alert('Failed');
            });

        
    })
    .factory("movieReviewsService",
    function ($http) {
        
        var fac = {}
        fac.GetMovieReviewsList = function (id) {
            return $http.get('/Movie/GetMovieReviewsByMovieId/' + id);
        }
        return fac;
    });