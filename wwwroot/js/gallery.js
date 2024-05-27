document.addEventListener("DOMContentLoaded", function () {
    const galleries = document.querySelectorAll(".gallery-instance");

    galleries.forEach((galleryInstance) => {
        let currentIdx = 0;
        const items = galleryInstance.querySelectorAll(".gallery-item");
        const thumbnails = galleryInstance.querySelectorAll(".thumbnail-image");
        const totalItems = items.length;

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
