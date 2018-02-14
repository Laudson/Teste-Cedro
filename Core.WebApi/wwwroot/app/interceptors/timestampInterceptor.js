angular.module('TesteCedro').factory("timestampInterceptor", function () {
	return {
        request: function (config) {

            config.headers = config.headers || {};

            config.headers['Authorization'] = 'Bearer ' + localStorage.getItem('tokenCore');
            
			return config;
		}
	};
});