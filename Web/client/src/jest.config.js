module.exports = ***REMOVED***
  roots: ["<rootDir>/src"],
  transform: ***REMOVED***
    "^.+\\.tsx?$": "ts-jest",
 ***REMOVED***,
  testRegex: "(/__tests__/.*|(\\.|/)(test|spec))\\.tsx?$",
  moduleFileExtensions: ["ts", "tsx", "js", "jsx", "json", "node"],
  snapshotSerializers: ["enzyme-to-json/serializer"],
  setupTestFrameworkScriptFile: "<rootDir>/src/setupEnzyme.ts",

  moduleNameMapper: ***REMOVED***
    "^components(.*)$": "<rootDir>/src/components$1",
 ***REMOVED***,
***REMOVED***;
