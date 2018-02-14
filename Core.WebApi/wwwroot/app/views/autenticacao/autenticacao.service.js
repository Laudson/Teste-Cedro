(function(){
    angular.module('TesteCedro')
    .factory('autenticacaoService', ['$resource', function($resource) 
    {
        var resource = $resource('/api/autenticacao',
            {
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                query: { isArray: false }
            }
        );
        return resource;
    }]);
})();