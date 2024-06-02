document.addEventListener("DOMContentLoaded", function () {
    const galleries = document.querySelectorAll(".gallery-instance");

    galleries.forEach((galleryInstance) => {
        let currentIdx = 0;
        const items = galleryInstance.querySelectorAll(".gallery-item");
        const thumbnails = galleryInstance.querySelectorAll(".thumbnail-image");
        const totalItems = items.length;

        items.forEach((item, idx) => {
            item.addEventListener('touchstart', function (event) {
                startX = event.touches[0].clientX;
                startY = event.touches[0].clientY;
            }, false);

            item.addEventListener('touchmove', function (event) {
            }, false);

            item.addEventListener('touchend', function (event) {
                const endX = event.changedTouches[0].clientX;
                const endY = event.changedTouches[0].clientY;

                const deltaX = endX - startX;
                const deltaY = endY - startY;

                // Check if vertical distance moved is more than twice the horizontal distance
                if (Math.abs(deltaY) > 2 * Math.abs(deltaX)) {
                    event.preventDefault(); // Prevent default scroll behavior
                } else {
                    // Swipe horizontal detection
                    if (Math.abs(deltaX) > Math.abs(deltaY)) {
                        if (deltaX < 0) {
                            currentIdx = (currentIdx + 1) % totalItems;
                        } else {
                            currentIdx = (currentIdx - 1 + totalItems) % totalItems;
                        }
                        updateGallery(currentIdx);
                    }
                }
            }, false);
        });

        function updateGallery(newIdx) {
            items.forEach((item, idx) => {
                item.classList.remove("current", "immediate", "far");
                item.style.transform = '';

                if (idx === newIdx) {
                    item.classList.add("current");
                    item.style.transform = `translateX(0) scale(1.2)`;
                } else if (idx === (newIdx + 1) % totalItems) {
                    item.classList.add("immediate");
                    item.style.transform = `translateX(100%) scale(0.8)`;
                } else if (idx === (newIdx - 1 + totalItems) % totalItems) {
                    item.classList.add("immediate");
                    item.style.transform = `translateX(-100%) scale(0.8)`;
                } else {
                    item.classList.add("far");
                    const offset = (idx - newIdx + totalItems) % totalItems;
                    const position = (offset > totalItems / 2 ? -(totalItems - offset) : offset) * 100;
                    item.style.transform = `translateX(${position}%) scale(0.8)`;
                }
            });

            thumbnails.forEach((thumbnail, idx) => {
                if (idx === newIdx) {
                    thumbnail.classList.add("selected");
                } else {
                    thumbnail.classList.remove("selected");
                }
            });

            currentIdx = newIdx;
        }

        items.forEach((item, idx) => {
            item.querySelector(".gallery-image").addEventListener("click", function () {
                if (item.classList.contains("immediate")) {
                    const newIdx = idx;
                    updateGallery(newIdx);
                }
            });

            // Initial class setup
            if (idx === currentIdx) {
                item.classList.add("current");
                thumbnails[idx].classList.add("selected");
                item.style.transform = `translateX(0) scale(1.2)`;
            } else if (idx === (currentIdx + 1) % totalItems) {
                item.classList.add("immediate");
                item.style.transform = `translateX(100%) scale(0.8)`;
            } else if (idx === (currentIdx - 1 + totalItems) % totalItems) {
                item.classList.add("immediate");
                item.style.transform = `translateX(-100%) scale(0.8)`;
            } else {
                item.classList.add("far");
                const offset = (idx - currentIdx + totalItems) % totalItems;
                const position = (offset > totalItems / 2 ? -(totalItems - offset) : offset) * 100;
                item.style.transform = `translateX(${position}%) scale(0.8)`;
            }
        });

        thumbnails.forEach((thumbnail, idx) => {
            thumbnail.addEventListener("click", function () {
                updateGallery(idx);
            });
        });
    });
});
