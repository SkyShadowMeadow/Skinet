// namespaceExtractor.js
const path = require('path');

function extractNamespace(directory) {
    const srcIndex = directory.indexOf("src");
    if (srcIndex !== -1) {
        const folders = directory.substring(srcIndex + 4).split(path.sep);
        // Remove the first folder if it's the project name
        if (folders[0] === "YourProjectName") {
            folders.shift();
        }
        return folders.join('.');
    } else {
        return "";
    }
}

module.exports = extractNamespace;