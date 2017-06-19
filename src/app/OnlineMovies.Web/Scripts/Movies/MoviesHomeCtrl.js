
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