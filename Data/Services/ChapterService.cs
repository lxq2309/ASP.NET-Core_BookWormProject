﻿using BookWormProject.Data.Repository;
using BookWormProject.Models;

namespace BookWormProject.Data.Services
{
    public class ChapterService : IChapterService
    {
        private readonly IChapterRepository _chapterRepository;
        private readonly IArticleService _articleService;

        public ChapterService(IChapterRepository chapterRepository, IArticleService articleService)
        {
            _chapterRepository = chapterRepository;
            _articleService = articleService;
        }

        public void AddChapter(Chapter chapter)
        {
            _chapterRepository.Add(chapter);
        }

        public void DeleteChapter(int id)
        {
            _chapterRepository.Delete(GetById(id));
        }

        public IEnumerable<Chapter> GetAllChapters()
        {
            return _chapterRepository.GetAll();
        }

        public Chapter GetById(int id)
        {
            return _chapterRepository.GetById(id);
        }

        public Chapter? GetChapterByIndex(int articleId, int index)
        {
            var chapters = _articleService.GetChaptersForArticle(articleId);
            return chapters.SingleOrDefault(x => x.Index == index);
        }

        public void UpdateChapter(Chapter chapter)
        {
            _chapterRepository.Update(chapter);
        }
    }
}