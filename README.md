# SemanticResourceManager

To handle language and culture specific translations

This project was inspired by the problem of a huge WebForms application with thousands of resource files (resx) and the maintanance of versions and translations. The goal is to find a more generic and flexible solution.

## Server Side

The most simple REST Api Interface. 
You can POST, PUT and GET a Resource.Value by key and language
Fallback

## Resource

A resource is defined by a unique key (Application Name + Element Identifier + Culture name)  
A resource has a set of properties (Title, Desciption, Icon, ...)

## Client Side
- Custom Resource provider to embed in a asp.net WebForm applications
- Tabular UI for translaters
- 

