angular.module('TesteCedro').factory("errorInterceptor", function ($q, $location) {
    return {
        responseError: function (rejection) {
            if (rejection.status === 401 || rejection.status === 403) {
                $location.path("/views/autenticacao/login");
            }
            return $q.reject(rejection);
        }
    };
});