function renderPagination(pageInfo) {
    if (pageInfo.totalPages == 1) {
        return;
    }
    var paginationHtml =
        `
                    <ul class="pagination pagination-sm">
                `;
    if (pageInfo.hasPreviousPage) {
        var firstLink = "<li><a href='#' data-page='" + 1 + "'>&laquo; First</a></li>";
        var prevLink = "<li><a href='#' data-page='" + (pageInfo.pageNumber - 1) + "'><span class='glyphicon glyphicon-menu-left'></span></a></li>";
        paginationHtml += firstLink;
        paginationHtml += prevLink;
    }
    for (var i = 1; i <= pageInfo.totalPages; i++) {
        var pageLink = "<li><a href='#' data-page='" + i + "'>" + i + "</a></li>";
        if (i == pageInfo.pageNumber) {
            pageLink = "<li class='active'><span>" + i + "<span class='sr-only'> (đang xem)</span></span></li>";
        }
        paginationHtml += pageLink;
    }
    if (pageInfo.hasNextPage) {
        var nextLink = "<li><a href='#' data-page='" + (pageInfo.pageNumber + 1) + "'><span class='glyphicon glyphicon-menu-right'></span></a></li>";
        var lastLink = "<li><a href='#' data-page='" + pageInfo.totalPages + "'>Last &raquo;</a></li>";
        paginationHtml += nextLink;
        paginationHtml += lastLink;
    }

    paginationHtml +=
        `</ul>`;

    return paginationHtml;
}

$(document).on('click', '#pagination a', function (e) {
    e.preventDefault();
    // Load dữ liệu mới
    var page = $(this).data('page');
    loadArticles(page);

    // Cuộn lên đầu trang khi chuyển trang
    var pageTitle = document.getElementById('list-page');
    animationScrollUp(pageTitle);
});

function animationScrollUp(pageTitle) {
    var targetPosition = pageTitle.getBoundingClientRect().top;
    var startPosition = window.pageYOffset;
    var distance = targetPosition - startPosition;
    var duration = 1000;
    var startTime = null;

    function animation(currentTime) {
        if (startTime === null) startTime = currentTime;
        var timeElapsed = currentTime - startTime;
        var run = ease(timeElapsed, startPosition, distance, duration);
        window.scrollTo(0, run);
        if (timeElapsed < duration) requestAnimationFrame(animation);
    }

    function ease(t, b, c, d) {
        t /= d / 2;
        if (t < 1) return c / 2 * t * t + b;
        t--;
        return -c / 2 * (t * (t - 2) - 1) + b;
    }

    requestAnimationFrame(animation);
}