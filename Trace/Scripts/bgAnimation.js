if (typeof sleek === "undefined") {
    var sleek = {};
}

(function ($, window) {
    function Constellation(canvas, options) {
        var $canvas = $(canvas),
			context = canvas.getContext('2d'),
			defaults = {
			    star: {
			        color: 'rgba(255, 255, 255, .15)',
			        width: 1
			    },
			    line: {
			        color: 'rgba(100, 255, 255, .2)',
			        width: 0.2
			    },
			    position: {
			        x: 0, // This value will be overwritten at startup
			        y: 0 // This value will be overwritten at startup
			    },
			    width: $canvas.parent().width(),
			    height: ($canvas.parent().height() - 160),
			    velocity: 0.1,
			    length: 50,
			    distance: 100,
			    radius: 150,
			    stars: [],
			    floats: []
			},
			config = $.extend(true, {}, defaults, options),
			aniFps = 30,
			aniNow, aniThen = Date.now(),
			aniInterval = 1000 / aniFps,
			anDelta;

        function Star() {
            this.x = Math.random() * canvas.width;
            this.y = Math.random() * canvas.height;

            this.vx = (config.velocity - (Math.random() * 0.5));
            this.vy = (config.velocity - (Math.random() * 0.5));

            this.radius = Math.random() * config.star.width;
        }

        Star.prototype = {
            create: function (i) {
                var math = Math.PI * 2
                context.beginPath();
                context.arc(this.x, this.y, this.radius, 0, math, false);

                //context.font = "8px Arial";
                //context.fillText(i, this.x + 2, this.y - 2);

                context.fill();
            },
            animate: function () {
                var i;
                for (i = 0; i < config.length; i++) {

                    var star = config.stars[i];

                    if (star.y < 0 || star.y > canvas.height) {
                        star.vx = star.vx;
                        star.vy = -star.vy;
                    } else if (star.x < 0 || star.x > canvas.width) {
                        star.vx = -star.vx;
                        star.vy = star.vy;
                    }

                    star.x += star.vx;
                    star.y += star.vy;
                }
            },
            line: function () {
                var length = config.length,
					iStar,
					jStar,
					i,
					j;

                for (i = 0; i < length; i++) {
                    for (j = 0; j < length; j++) {
                        iStar = config.stars[i];
                        jStar = config.stars[j];

                        if (
							(iStar.x - jStar.x) < config.distance &&
							(iStar.y - jStar.y) < config.distance &&
							(iStar.x - jStar.x) > -config.distance &&
							(iStar.y - jStar.y) > -config.distance
						) {
                            if (
								(iStar.x - config.position.x) < config.radius &&
								(iStar.y - config.position.y) < config.radius &&
								(iStar.x - config.position.x) > -config.radius &&
								(iStar.y - config.position.y) > -config.radius
							) {
                                context.beginPath();
                                context.moveTo(iStar.x, iStar.y);
                                context.lineTo(jStar.x, jStar.y);
                                context.stroke();
                                context.closePath();
                            }
                        }
                    }
                }
            }
        };

        this.createStars = function () {
            var length = config.length,
				star,
				i;

            context.clearRect(0, 0, canvas.width, canvas.height);

            for (i = 0; i < length; i++) {
                config.stars.push(new Star());
                star = config.stars[i];

                var float = Math.floor(Math.random() * 1000000) + i
                float = kendo.toString(float, "c");

                star.create(float);
            }

            star.line();
            star.animate();
        };

        this.setCanvas = function () {
            canvas.width = config.width;
            canvas.height = config.height;
        };

        this.setContext = function () {
            context.fillStyle = config.star.color;
            context.strokeStyle = config.line.color;
            context.lineWidth = config.line.width;
        };

        this.setInitialPosition = function () {
            if (!options || !options.hasOwnProperty('position')) {
                config.position = {
                    x: canvas.width * 0.5,
                    y: canvas.height * 0.5
                };
            }
        };

        this.loop = function (callback) {

            aniNow = Date.now();
            aniDelta = aniNow - aniThen;

            if (aniDelta > aniInterval) {
                callback();
                aniThen = aniNow - (aniDelta % aniInterval);
            }

            window.requestAnimationFrame(function () {
                this.loop(callback);
            }.bind(this));
        };

        this.bind = function () {
            $canvas.on('mousemove', function (e) {
                config.position.x = e.pageX - $canvas.offset().left;
                config.position.y = e.pageY - $canvas.offset().top;
            });
        };

        this.init = function () {
            this.setCanvas();
            this.setContext();
            this.setInitialPosition();
            this.loop(this.createStars);
            this.bind();
        };
    }

    $.fn.constellation = function (options) {
        return this.each(function () {
            var c = new Constellation(this, options);
            c.init();
        });
    };
})(jQuery, window);

function bgAnimation_load(canvas, c1, c2) {
    jQuery(canvas).constellation({
        star: {
            color: c1,
            width: 3
        },
        line: {
            color: c2
        },
        radius: 150,
        length: 50,
        distance: 250
    });
};