# dynamicskypebot
A Skype "bot" written in C#

Original documentation can be viewed at: http://mathemaniac.org/wp/dynamic-skype-bot/

## Updates in this fork:
* The Wikipedia plugin has been partially fixed and will now correctly respond to single-word Wikipedia searches.
* The Wikipedia plugin now responds to !wiki <word> and !wikilong <word>; !wiki responds with the first paragraph of  the article while !wikilong responds with the entire first section of the article.
* The YouTube plugin has been fixed, but will require an API key to do lookups. The location for the key is commented near the top of the code.
* The YouTube plugin now displays like/dislike ratios as a percentage, rather than out of 5.

## Known issues present in this fork:
* The Wikipedia plugin will respond with a blank message if  you use a multiple-word input.

## Contact (for this fork):
If you really need to get in touch for something, the easiest way might be to poke /u/MHLoppy on reddit or yell at @MHLoppy on Twitter.
