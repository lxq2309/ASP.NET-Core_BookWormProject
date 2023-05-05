function renderComment(comments, currentUserId) {
    let commentHtml = "";
    for (var i = 0; i < comments.length; i++) {
        commentHtml +=
            `
                <div class="item clearfix" id="comment_${comments[i].commentId}">
                    <figure class="avatar">
                        <img src="${comments[i].user.avatar}" class="lazy" data-original="${comments[i].user.avatar}" alt="${comments[i].user.userName}">
                    </figure>
                    <div class="summary">
                        <i class="fa fa-angle-left fa-arrow">
                        </i>
                        <div class="info">
                            <div class="comment-header"><a href="/tai-khoan/${comments[i].user.userId}"><span class="authorname">${comments[i].user.userName}</span></a>
                                <abbr title="${comments[i].createdAt}">
                                    <i class="fa-regular fa-clock"></i> ${comments[i].timeAgo}
                                </abbr>
                                <a class="single-comment" data-comment-id="${comments[i].commentId}">
                                    ${
                                        comments[i].user.userId == currentUserId
                                        ? '<i class="glyphicon glyphicon-trash" style="color: #ff0000;"></i> delete'
                                        : ''
                                    }
                                </a>
                            </div>
                            <div class="comment-content">${comments[i].content}</div>
                        </div>
                        <div id="comment_form_${comments[i].commentId}">
                        </div>
                    </div>
                </div>
            `;
    }
    return commentHtml;
}