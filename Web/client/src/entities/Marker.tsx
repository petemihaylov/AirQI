import ***REMOVED*** IMarker***REMOVED*** from "./IMarker";

export default class MarkerEntity implements IMarker ***REMOVED***
  name: any;

  id: number | undefined;
  longitude: number | undefined;
  latitude: number | undefined;

  constructor();
  constructor(
    _longitude: number,
    _latitude: number
  );
  constructor(
    _longitude?: number,
    _latitude?: number
  ) ***REMOVED***
    this.longitude = _longitude;
    this.latitude = _latitude;
 ***REMOVED***
***REMOVED***
