function renderArticles(articles, title) {
    let articleHtml =
        `
                    <div class="title-list">
                        <h2>
                            ${title}
                        </h2>
                    </div>
                `;
    for (let i = 0; i < articles.length; i++) {
        const article = articles[i];
        let chapterHtml = '';
        if (article.chapters.length === 0) {
            chapterHtml = `
                            <span class="chapter-text">
                              Chưa có chương nào
                            </span>
                          `;
        } else {
            const newestChapter = article.chapters.reduce((max, current) => max.Index > current.Index ? max : current);
            chapterHtml = `
                            <a title="${newestChapter.title}" href="/p/${article.articleId}/${newestChapter.index}">
                              <span class="chapter-text">
                                ${newestChapter.title}
                              </span>
                            </a>
                          `;
        }

        let labelHtml = '';
        if (article.isCompleted) {
            labelHtml = '<span class="label-title label-full"></span>';
        }

        let authorHtml = '';
        for (let j = 0; j < article.authors.length; j++) {
            authorHtml += `
                            <span class="author" itemprop="author">
                              ${article.authors[j].name}
                            </span>
                          `;
        }

        articleHtml += `
                          <div class="row" itemscope="" itemtype="https://schema.org/Book">
                            <div class="col-xs-3">
                              <div><img src="${article.coverImage}" class="cover" alt="title"></div>
                            </div>
                            <div class="col-xs-7">
                              <div>
                                <span class="glyphicon glyphicon-book"></span>
                                <h3 class="truyen-title" itemprop="name">
                                  <a href="/p/${article.articleId}" title="${article.title}" itemprop="url">
                                    ${article.title}
                                  </a>
                                </h3>
                                ${labelHtml}
                                ${authorHtml}
                              </div>
                            </div>
                            <div class="col-xs-2 text-info">
                              <div>
                                ${chapterHtml}
                              </div>
                            </div>
                          </div>
                        `;
    }

    return articleHtml;
}