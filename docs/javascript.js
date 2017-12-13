

// Example of a callback pluging
//

							(function($){
							  $.fn.myAwesomePlugin = function(settings) {

									var defaults = {
										alertLog: 'hey'
									}
							    var callback = settings.callback;

							    if ($.isFunction(callback)) {
							      var parameter = 'Hello World';
										console.log('callback');
							      callback.call(this, parameter);
							    }

									return this.each (function (instance) {
										var plugin = {};
					          plugin.el = $(this);

									var instSome = function () {
										if(plugin.settings.alertLog) {
												alert('Log');
												console.log('SomeLog');
										}
									}

									plugin.settings = $.extend({}, defaults, settings);
									instSome();
									});

							  };
							})(jQuery);

							$("#breakspace").myAwesomePlugin({
							  callback: function(data){
							    alert(data);
							  }
							});

// ============================= end of the callback example =============================================== //
