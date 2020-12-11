import $ from "jquery";
import "gsap";
import ***REMOVED*** SlowMo***REMOVED*** from "gsap/EasePack";
import ***REMOVED*** Elastic, TimelineLite***REMOVED*** from "gsap";

export const animation = () => ***REMOVED***
  $(".button--bubble").each(function () ***REMOVED***
    var $circlesTopLeft = $(this).parent().find(".circle.top-left");
    var $circlesBottomRight = $(this).parent().find(".circle.bottom-right");

    var tl = new TimelineLite();
    var tl2 = new TimelineLite();

    var btTl = new TimelineLite(***REMOVED*** paused: true***REMOVED***);

    tl.to($circlesTopLeft, 1.2, ***REMOVED***
      x: -25,
      y: -25,
      scaleY: 2,
      ease: SlowMo.ease.config(0.1, 0.7, false),
   ***REMOVED***);
    tl.to($circlesTopLeft.eq(0), 0.1, ***REMOVED*** scale: 0.2, x: "+=6", y: "-=2"***REMOVED***);
    tl.to(
      $circlesTopLeft.eq(1),
      0.1,
      ***REMOVED*** scaleX: 1, scaleY: 0.8, x: "-=10", y: "-=7"***REMOVED***,
      "-=0.1"
    );
    tl.to(
      $circlesTopLeft.eq(2),
      0.1,
      ***REMOVED*** scale: 0.2, x: "-=15", y: "+=6"***REMOVED***,
      "-=0.1"
    );
    tl.to($circlesTopLeft.eq(0), 1, ***REMOVED***
      scale: 0,
      x: "-=5",
      y: "-=15",
      opacity: 0,
   ***REMOVED***);
    tl.to(
      $circlesTopLeft.eq(1),
      1,
      ***REMOVED*** scaleX: 0.4, scaleY: 0.4, x: "-=10", y: "-=10", opacity: 0***REMOVED***,
      "-=1"
    );
    tl.to(
      $circlesTopLeft.eq(2),
      1,
      ***REMOVED*** scale: 0, x: "-=15", y: "+=5", opacity: 0***REMOVED***,
      "-=1"
    );

    var tlBt1 = new TimelineLite();
    var tlBt2 = new TimelineLite();

    tlBt1.set($circlesTopLeft, ***REMOVED*** x: 0, y: 0, rotation: -45***REMOVED***);
    tlBt1.add(tl);

    tl2.set($circlesBottomRight, ***REMOVED*** x: 0, y: 0***REMOVED***);
    tl2.to($circlesBottomRight, 1.1, ***REMOVED***
      x: 30,
      y: 30,
      ease: SlowMo.ease.config(0.1, 0.7, false),
   ***REMOVED***);
    tl2.to($circlesBottomRight.eq(0), 0.1, ***REMOVED*** scale: 0.2, x: "-=6", y: "+=3"***REMOVED***);
    tl2.to(
      $circlesBottomRight.eq(1),
      0.1,
      ***REMOVED*** scale: 0.8, x: "+=7", y: "+=3"***REMOVED***,
      "-=0.1"
    );
    tl2.to(
      $circlesBottomRight.eq(2),
      0.1,
      ***REMOVED*** scale: 0.2, x: "+=15", y: "-=6"***REMOVED***,
      "-=0.2"
    );
    tl2.to($circlesBottomRight.eq(0), 1, ***REMOVED***
      scale: 0,
      x: "+=5",
      y: "+=15",
      opacity: 0,
   ***REMOVED***);
    tl2.to(
      $circlesBottomRight.eq(1),
      1,
      ***REMOVED*** scale: 0.4, x: "+=7", y: "+=7", opacity: 0***REMOVED***,
      "-=1"
    );
    tl2.to(
      $circlesBottomRight.eq(2),
      1,
      ***REMOVED*** scale: 0, x: "+=15", y: "-=5", opacity: 0***REMOVED***,
      "-=1"
    );

    tlBt2.set($circlesBottomRight, ***REMOVED*** x: 0, y: 0, rotation: 45***REMOVED***);
    tlBt2.add(tl2);

    btTl.add(tlBt1);
    btTl.to(
      $(this).parent().find(".button.effect-button"),
      0.8,
      ***REMOVED*** scaleY: 1.1***REMOVED***,
      0.1
    );
    btTl.add(tlBt2, 0.2);
    btTl.to(
      $(this).parent().find(".button.effect-button"),
      1.8,
      ***REMOVED*** scale: 1, ease: Elastic.easeOut.config(1.2, 0.4)***REMOVED***,
      1.2
    );

    btTl.timeScale(2.6);

    $(this).on("mouseover", function () ***REMOVED***
      btTl.restart();
   ***REMOVED***);
 ***REMOVED***);
***REMOVED***;
