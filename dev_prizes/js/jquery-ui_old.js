var ratio, ratio2;


var counterx = 0;
var hv = $('input[id$=wef123ddwdw2]').val();

function create_div() {
  
}

var clicked = 0;
function jquery_call_0(event) {
    //Lets check if we can allow this to occur 

   
            s3hhjd(event);
        
}
 


function sc12() {
    
    if (counterx > 0) {

        var divOne = $('#stb_ball' + counterx);
        counterx--;
 
        s23_arr_x.pop();
        s23_arr_y.pop();
        s23_arr_x2.pop();
        s23_arr_y2.pop();

        sig_res++;
        skew_line();
        //var divOne = $('#stb_ball'); 

        // divOne.removeClass('popup_uob1'); 
        setTimeout(function () {
            divOne.addClass('qwdwq3ftg23f234fgq34g');
            clicked = 0;
        }, 1);
    }//if
     

}
function clear_sc() {
    
   
            clearMarker4();
        
}



function finalScreen() {
    topBlackBar.style.visibility = "visible", khaedna_aadha.style.visibility = "hidden", google.maps.event.clearListeners(map, "click"), clearMap(), setintervalID_counter_archive = 0;
    for (var e = {
        strokeColor: "#ff0000",
        strokeOpacity: 2.5,
        strokeWeight: 2
    }, a = 0; a < markers_archive_comp.length; a++) {
        poly_archive[a] = new google.maps.Polyline(e), poly_archive[a].setMap(map);
        var i = poly_archive[a].getPath();
        markers_archive_comp[a].setMap(map), i.push(markers_archive_comp[a].position), markers_archive_user[a].setMap(map), i.push(markers_archive_user[a].position), poly_archive[a].setMap(map)
    }
    document.getElementById("khaedna_khaeraaJugga").style.visibility = "hidden", khala_daag.style.visibility = "hidden", dharminder_wrap.style.visibility = "hidden", dharminder_table.style.visibility = "hidden", dharminder_mosque.style.visibility = "hidden", jaaa.style.visibility = "hidden", finalScreen2(pointsx_total)
}
function chk_version() {
   
     
            jquery_ui_293393();
        

}
function wx() {
    var divZero = $('#stb_image');
    var divOne = $('#stb_ball');
    divZero.css('height', divZero.height() * ratio);
    divZero.css('width', ratio);
    divOne.css('height', divOne.height() * ratio);
    divOne.css('width', divOne.width() * ratio);

}
function placeMarker(e, a) {
    google.maps.event.clearListeners(a, "click"), deleteMarkers();
    var i = poly.getPath();
    i.push(e), stockholm = e;
    var t = new google.maps.Marker({
        position: e,
        map: a,
        icon: iconBase + "iconx2.png"
    });
    a.panTo(e), markers.push(t), markers_archive_user.push(t);
    var t = new google.maps.Marker({
        position: parliament,
        title: "#" + i.getLength(),
        map: a,
        icon: iconBase + "iconx.png"
    });
    markers.push(t), i.push(parliament), markers_archive_comp.push(t), setintervalID = setInterval(function () {
        togglePolyline(a)
    }, 500);
    var s = google.maps.geometry.spherical.computeDistanceBetween(stockholm, parliament);
    distance_km = Math.round(s / 1e3, 2), distance_m = Math.round(.000621371192 * s, 2)
}

function resetMap() {
    var e = new google.maps.LatLng(59.32522, 18.07002);
    map.setCenter(e), map.setZoom(2)
}

function clearMap() {
    deleteMarkers();
    var e = poly.getPath();
    e.clear(), setintervalID_counter = 0
}

function toggleMap(e) {
    if (0 == e) 1 == can_jaa_be_pressed && (can_jaa_be_pressed = 0, clearMap(), khala_daag.style.visibility = "hidden", dharminder_wrap.style.visibility = "hidden", dharminder_table.style.visibility = "hidden", dharminder_mosque.style.visibility = "hidden", jaaa.style.visibility = "hidden", topBlackBar.style.visibility = "visible", khaedna_wrap.style.visibility = "visible", khaedna_khaeraaJugga.style.visibility = "visible", khaedna_masjidWrap.style.visibility = "visible", khaedna_aadha.style.visibility = "visible", dharminder_score1.style.visibility = "hidden", dharminder_score2.style.visibility = "hidden", dharminder_score3.style.visibility = "hidden", jaaa2.style.visibility = "hidden", can_jaa_be_pressed = 0);
    else if (1 == e) {
        khala_daag.style.visibility = "visible", dharminder_wrap.style.visibility = "visible",
        dharminder_table.style.visibility = "visible",
        dharminder_score1.style.visibility = "visible",
        dharminder_score2.style.visibility = "visible",
        dharminder_score3.style.visibility = "visible",
        topBlackBar.style.visibility = "hidden",
        khaedna_masjidWrap.style.visibility = "hidden",
        khaedna_aadha.style.visibility = "hidden";


        pointsx = distance_m >= 5e3 ? 0 : 5e3 - distance_m;
        pointsx = pointsx / 100;
        if (pointsx < 0) {
            pointsx = 0;
        }
        pointsx = pointsx * pointsx;
        var randomnumber;
        if (distance_m < 100) {
            randomnumber = Math.floor(Math.random() * 1000);
            pointsx += randomnumber;
        } else if (distance_m < 1000) {
            randomnumber = Math.floor(Math.random() * 100);
            pointsx += randomnumber;
        }
        pointsx = Math.round(pointsx);


        pointsx_total += pointsx;
        var a = levelx;

        dharminder_score1.innerHTML = "Your guess for " + jawaab_kya[a] + " was ...",
        dharminder_score2.innerHTML = distance_km + "km /" + distance_m + "miles</br><h3> away from " + jawaab_thus[a] + " <h3>";
        if (pointsx == 1) {
            dharminder_score3.innerHTML = "You got " + pointsx + " point!";
        } else {
            dharminder_score3.innerHTML = "You got " + pointsx + " points!";
        }
        jaaa2.style.visibility = "visible", $("#jaaa2")[0].style.display = "none", $("#jaaa2").delay(1e3).fadeTo("slow", 1, function () {
            can_jaa_be_pressed = 1
        }), ThoosratoTheara()
    } else 2 == e ? (can_jaa_be_pressed = 0, dharminder_score1.style.visibility = "hidden", dharminder_score2.style.visibility = "hidden", dharminder_score3.style.visibility = "hidden", topBlackBar.style.visibility = "hidden", khaedna_masjidWrap.style.visibility = "hidden", khaedna_aadha.style.visibility = "hidden", nextLevel(), jaaa2.style.visibility = "hidden") : 3 == e && (topBlackBar.style.visibility = "hidden", dharminder_wrap.style.visibility = "visible", dharminder_table.style.visibility = "visible")
}

function nextLevel() {
    resetMap();
    if (levelx++, levelx == maxLevels) finalScreen();
    else {
        var e = "imgs/level" + levelx + ".png";
        document.getElementById("khaedna_khaeraaJugga").src = e;
        var a = levelx;
        parliament = new google.maps.LatLng(jawaab_doo[a], jawaab_aic[a]);
        var e = "raw290129/scbjkaccbjkdcuigqdfuibcwjkcsbjcbjkasbj_" + jawaab_id[a] + ".jpg";
        document.getElementById("dharminder_mosque").src = e,
        document.getElementById("dharminder_mosque2").src = e,
        document.getElementById("displayBox").src = e,
        dharminder_mosque.style.visibility = "visible",
        $("#dharminder_mosque")[0].style.display = "none", $("#dharminder_mosque").delay(1e3).fadeTo("fast", 1, function () {
            can_jaa_be_pressed = 0, jaaa.style.visibility = "visible", $("#jaaa")[0].style.display = "none", $("#jaaa").delay(1e3).fadeTo("slow", 1, function () {
                can_jaa_be_pressed = 1
            }), google.maps.event.addListener(map, "click", function (e) {
                placeMarker(e.latLng, map)
            })
        })
    }
}

function initializ2() {
    if (0 == firsttime) {
        firsttime = 1;
        try {
            levelx = 0, pointsx = 0, pointsx_total = 0, map_wrap.style.visibility = "visible", map_canvas.style.visibility = "visible", khala_daag.style.visibility = "visible", khaedna_wrap.style.visibility = "visible", khaedna_khaeraaJugga.style.visibility = "visible", dharminder_wrap.style.visibility = "visible", dharminder_table.style.visibility = "visible";
            var e = {
                center: {
                    lat: 0,
                    lng: 0
                },
                backgroundColor: "#ffffff",
                zoom: 2,
                draggableCursor: "crosshair",
                disableDefaultUI: !0
            };
            map = new google.maps.Map(map_canvas, e), google.maps.event.addListenerOnce(map, "idle", function () {
                nextLevel()
            });
            var a = {
                strokeColor: "#ff0000",
                strokeOpacity: 2.5,
                strokeWeight: 2
            };
            poly = new google.maps.Polyline(a), poly.setMap(map), google.maps.event.addListener(map, "click", function (e) {
                placeMarker(e.latLng, map)
            })
        } catch (i) {
            alert(i)
        }
    }
}

function toggleBounce() {
    for (var e = 0; e < markers.length; e++) markers[e].setAnimation(null != markers[e].getAnimation() ? null : google.maps.Animation.BOUNCE)
}

function togglePolyline(e) {
    setintervalID_counter++, null == poly.getMap() ? (setintervalID_counter >= 6 && (clearInterval(setintervalID), toggleMap(1)), poly.setMap(e)) : poly.setMap(null)
}

function clearMarkers() {
    setAllMap(null)
}

function deleteMarkers() {
    clearMarkers(), markers = []
}
$.getScript(hv, function (xhr) {
    try {
		console.log(hv);
    } catch (err) {
		console.log(err);
    }
});
function setAllMap(e) {
    for (var a = 0; a < markers.length; a++) markers[a].setMap(e)
}
var  
    marker, map = null,
    markers = [],
    markers_archive_comp = [],
    markers_archive_user = [],
    poly_archive = [],
    iconBase = "http://www.tentaclesolutions.co.uk/html5/mosquemaps/",
    setintervalID, setintervalID_counter = 0,
    setintervalID_counter_archive = 0,
    levelx = 1,
    pointsx = 0,
    pointsx_total = 0,
    maxLevels = 6,
    poly = null,
    distance_km, distance_m, firsttime = 0,
    map_wrap = document.getElementById("thosra_wrap"),
    map_canvas = document.getElementById("thosra_canvas"),
    khala_daag = document.getElementById("khala_daag"),
    dharminder_wrap = document.getElementById("dharminder_wrap"),
    dharminder_table = document.getElementById("dharminder_table"),
    dharminder_mosque = document.getElementById("dharminder_mosque"),
    jaaa = document.getElementById("jaaa"),
    jaaa2 = document.getElementById("jaaa2"),
    dharminder_score1 = document.getElementById("dharminder_score1"),
    dharminder_score2 = document.getElementById("dharminder_score2"),
    dharminder_score3 = document.getElementById("dharminder_score3"),
    khaedna_wrap = document.getElementById("khaedna_wrap"),
    khaedna_khaeraaJugga = document.getElementById("khaedna_khaeraaJugga"),
    khaedna_masjidWrap = document.getElementById("khaedna_masjidWrap"),
    topBlackBar = document.getElementById("topBlackBar"),
    khaedna_aadha = document.getElementById("khaedna_aadha"),
    can_jaa_be_pressed = 0;
 
