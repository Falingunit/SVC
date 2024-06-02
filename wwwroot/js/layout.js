// Check if the device is a touchscreen
function isTouchDevice() {
    return 'ontouchstart' in window        // works on most browsers 
        || navigator.maxTouchPoints > 0;   // works on IE10/11 and Surface
}

// Function to handle dropdown behavior
function handleDropdownClick(event) {
    if (isTouchDevice()) {
        // Check if the dropdown is already open
        if (event.target.classList.contains('show')) {
            // Open the page linked to by the dropdown
            window.location.href = event.target.getAttribute('href');
        } else {
            // Prevent the default behavior of the click event
            event.preventDefault();
            // Add the 'show' class to the dropdown to make it visible
            event.target.classList.add('show');

            // Add event listener to hide dropdown content when it loses focus
            document.addEventListener('touchstart', function(event) {
                var dropdownContent = event.target.closest('.dropdown-content');
                if (dropdownContent && !dropdownContent.contains(event.target)) {
                    dropdownContent.style.display = 'none';
                }
            });
        }
    }
}

// Add event listener to the dropdown links
var dropdownLinks = document.querySelectorAll('.dropdown-toggler');
dropdownLinks.forEach(function(link) {
    link.addEventListener('click', handleDropdownClick);
});
// When the user scrolls the page, execute myFunction
window.onscroll = function () { myFunction() };

function resizeMap() {
    var map = document.getElementById('map');
    map.attributes.width = window.innerWidth;
}

window.addEventListener('resize', resizeMap);
resizeMap();