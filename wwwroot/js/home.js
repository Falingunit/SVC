document.addEventListener('DOMContentLoaded', (event) => {
    const scrollContainer = document.querySelector('.scroll-container');
    const pages = document.querySelectorAll('.page-container');
    const prevButton = document.getElementById('prev');
    const nextButton = document.getElementById('next');

    let currentPage = 0;

    function updateActivePage() {
        pages.forEach((page, index) => {
            if (index === currentPage) {
                page.classList.add('active');
            } else {
                page.classList.remove('active');
            }
        });
    }

    function scrollToPage(index) {
        currentPage = index;
    const offset = pages[index].offsetLeft - scrollContainer.offsetLeft;
    scrollContainer.scrollTo({left: offset, behavior: 'smooth' });
    updateActivePage();
    }

    nextButton.addEventListener('click', () => {
        if (currentPage < pages.length - 1) {
        scrollToPage(currentPage + 1);
        }
    });

    prevButton.addEventListener('click', () => {
        if (currentPage > 0) {
        scrollToPage(currentPage - 1);
        }
    });

    // Initialize the first page as active
    updateActivePage();
});