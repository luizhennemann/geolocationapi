# **Geo Location API**
### Calculates distance between two points.

This API offers three ways of calculating the distance between two points on the surface of the Earth.

#### Calculate Distance Haversine

**According to Wikipedia:** "The haversine formula determines the great-circle distance between two points on a sphere given their longitudes and latitudes. Important in navigation, it is a special case of a more general formula in spherical trigonometry, the law of haversines, that relates the sides and angles of spherical triangles."

Source: https://en.wikipedia.org/wiki/Haversine_formula

#### Calculate Distance Spherical Law Of Cosines

**According to Wikipedia:** "In spherical trigonometry, the law of cosines (also called the cosine rule for sides) is a theorem relating the sides and angles of spherical triangles, analogous to the ordinary law of cosines from plane trigonometry."

Formula: cos p = cos a cos b + sin a sin b cos φ

Source: https://en.wikipedia.org/wiki/Spherical_law_of_cosines

#### Calculate Earth Projection Pythagoras

**According to Wikipedia:** "Geographical distance is the distance measured along the surface of the earth. The formulae in this article calculate distances between points which are defined by geographical coordinates in terms of latitude and longitude. This distance is an element in solving the second (inverse) geodetic problem."

Source: http://en.wikipedia.org/wiki/Geographical_distance



#### Techincal API Design

The API was build using C# .Net Core. There are two projects:

1) The API exposure through a controller
2) Integration tests and unit tests

##### **P.S.: Also, the API can be tested using Swagger. Once the API is up and running: http://YOUR-HOST/swagger**
