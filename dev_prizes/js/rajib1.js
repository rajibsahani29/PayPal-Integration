var GlobalX=0;
var GlobalY=0;

function zoom(attributes)
{
    var $element = $(".stb_imageZoom");
    //var $element = $("#canvasTemp");

    // If the target element is not an image
    /*if (!$element.is("img")) {
      console.log("%c zoom.js Error: " + "%cTarget element is not an image.", 
        "background: #FCEBB6; color: #F07818; font-size: 17px; font-weight: bold;",
        "background: #FCEBB6; color: #F07818; font-size: 17px;");
      return;
    }*/

    // Constants
    var $IMAGE_URL    = "images/900.jpg"; //$element.attr("src");
    var $IMAGE_WIDTH  = $element.width();
    var $IMAGE_HEIGHT = $element.height();
    var NATIVE_IMG    = new Image();
    NATIVE_IMG.src    = "images/900.jpg"; //$element.attr("src");

    // Default attributes
    var defaults = {
      round      : true,
      width      : 75,
      height     : 75,
      background : "#FFF",
      shadow     : "0 8px 17px 0 rgba(0, 0, 0, 0.2)",
      border     : "2px solid #FFF",
      cursor     : true,
      zIndex     : 999999,
      scale      : 1
    }

    // Update defaults with custom attributes
    var $options = $.extend(defaults, attributes);

    // Modify target image
    $element.on('dragstart', function (e) { e.preventDefault(); });
    $element.css("cursor", $options.cursor ? "crosshair" : "none");

    // Create magnification lens element
    var lens = document.createElement("div");
    lens.id = "ZoomLens";

    // Attack the element to the body
    $("body").append(lens);

    // Updates styles
    $zoomLens = $("#ZoomLens");

    var coSpan = document.createElement("span");
    coSpan.id = "spnCoordinates";
    coSpan.style="position: absolute;top: -28px;left: -6px;color: #FFFFFF;white-space: nowrap;font-size: 14px;font-weight: 700;text-shadow: 1px 0 0 #333333, -1px 0 0 #333333, 0 1px 0 #333333, 0 -1px 0 #333333, 1px 1px #333333, -1px -1px 0 #333333, 1px -1px 0 #333333, -1px 1px 0 #333333;";
    $("#ZoomLens").append(coSpan);

    $zoomLens.css({
      "position"          : "absolute",
      "visibility"        : "hidden",
      "pointer-events"    : "none",
      "zIndex"            : $options.zIndex,
      "width"             : $options.width,
      "height"            : $options.height,
      "border"            : $options.border,
      "background"        : $options.background,
      "border-radius"     : $options.round ? "50%" : "none",
      "box-shadow"        : $options.shadow,
      "background-repeat" : "no-repeat",
    });

    // Show magnification lens
    $element.mouseenter(function () {
      $zoomLens.css("visibility", "visible");
    })

    // Mouse motion on image
    $element.mousemove(function (e) {

      // Lens position coordinates
      var lensX = e.pageX - $options.width / 2;
      var lensY = e.pageY - $options.height / 2;

      //console.log("lensX=" + lensX + ", lensY=" + lensY);

	  // Relative coordinates of image
      var relX = e.pageX - $(this).offset().left;
      var relY = e.pageY - $(this).offset().top;
	  
      //console.log("relX=" + relX + ", relY=" + relY);

      // Zoomed image coordinates 
      //console.log("relX = " + relX);
      //console.log("$element.width() = " + $element.width());
      //console.log("NATIVE_IMG.width = " + NATIVE_IMG.width);
      //console.log("$options.scale = " + $options.scale);
      //console.log("$options.width = " + $options.width);

      var zoomX = -Math.floor(relX / $element.width() * (NATIVE_IMG.width * $options.scale) - $options.width / 2);
      var zoomY = -Math.floor(relY / $element.height() * (NATIVE_IMG.height * $options.scale) - $options.height / 2);

      //console.log("zoomX=" + zoomX + ", zoomY=" + zoomY);

      $("#spnCoordinates").html("X = " + Math.abs(zoomX-35) + " Y = " + Math.abs(zoomY-36));
      GlobalX = Math.abs(zoomX-35);
      GlobalY = Math.abs(zoomY-36);
      //$("#spnCoordinates").html("X = " + zoomX + " Y = " + zoomY);

      var backPos = zoomX + "px " + zoomY + "px";
      var backgroundSize = NATIVE_IMG.width * $options.scale + "px " + NATIVE_IMG.height * $options.scale + "px";

      // Apply styles to lens
      $zoomLens.css({
        left                  : lensX,
        top                   : lensY,
        "background-image"    : "url(" + $IMAGE_URL + ")",
        "background-size"     : backgroundSize,
        "background-position" : backPos
      });

    })

    // Hide magnification lens
    $element.mouseleave(function () {
      $zoomLens.css("visibility", "hidden");
    })
}

/*$(function ($) {

  $.fn.zoom = function (attributes) {

    

  }
})*/
