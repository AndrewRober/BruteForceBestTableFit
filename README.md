# Brute Force Best Table Fit
brute forcing the best table fit for entities in categories

![](https://personal-cdn.s3.amazonaws.com/imgs/possibilities.PNG)


------------


##### development for this application have been discontinued, I started working on it to get the best fit for a table to use in some website, it's fully functional for it's purpose but i will no longer update it

# Description:

This application is used to fit entities n with multiple categories m in a table with rows count Rn and columns count Cn that sums up to m using the pegionhole priciple to fit entities intersection I (where Intersection count Ic must be the same as number of entities in tables generation for the table to be valid) for any number of categories m where m could be strictly row, column or interchangable and each entity could have 2 or more categories to be able to fit in the 2 dimensional table (sorry if it sounds complicated but it's rather simple when you break it down with pen and paper)

the use cases for this application is endless, rows could be hours, columns be days and the entities be activities to fit in the table, etc..

# Features
- you can use any number of entities or categories
- each entity can have 2 or more cateogires
- each category could represent column, row or be interchangable to increase the possibilities
- each valid table possibility gets a horizontal and vertical score to assist which is the best table to use
- on the last version, i've omitted the sorting based on the horizontal and vertical score as out of 16 million possibility, only 4 tables were valid, nevertheless, added few lines to serialize the result and print it
