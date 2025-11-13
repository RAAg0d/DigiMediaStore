import React, { useState, useEffect } from 'react';
import './App.css';
import axios from 'axios';

const API_URL = process.env.REACT_APP_API_URL || 'http://localhost:8080';

function App() {
  const [apiStatus, setApiStatus] = useState('checking');
  const [contents, setContents] = useState([]);
  const [genres, setGenres] = useState([]);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    checkApiConnection();
  }, []);

  const checkApiConnection = async () => {
    try {
      const response = await axios.get(`${API_URL}/swagger/index.html`);
      setApiStatus('connected');
    } catch (error) {
      try {
        // Попробуем проверить через API endpoint
        await axios.get(`${API_URL}/api`);
        setApiStatus('connected');
      } catch (err) {
        setApiStatus('disconnected');
      }
    }
  };

  const fetchContents = async () => {
    setLoading(true);
    try {
      const response = await axios.get(`${API_URL}/api/Content`);
      setContents(response.data || []);
    } catch (error) {
      console.error('Ошибка при загрузке контента:', error);
      setContents([]);
    } finally {
      setLoading(false);
    }
  };

  const fetchGenres = async () => {
    setLoading(true);
    try {
      const response = await axios.get(`${API_URL}/api/Genre`);
      setGenres(response.data || []);
    } catch (error) {
      console.error('Ошибка при загрузке жанров:', error);
      setGenres([]);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="App">
      <header className="App-header">
        <div className="container">
          <h1 className="title">🎬 DigiMediaStore</h1>
          <p className="subtitle">Платформа для продажи и аренды цифрового медийного контента</p>
          
          <div className="status-indicator">
            <div className={`status-badge ${apiStatus === 'connected' ? 'connected' : 'disconnected'}`}>
              {apiStatus === 'connected' ? '✓ API подключен' : '✗ API недоступен'}
            </div>
            <p className="api-url">API URL: {API_URL}</p>
          </div>

          <div className="features">
            <div className="feature-card">
              <div className="feature-icon">🎬</div>
              <h3>Фильмы и сериалы</h3>
              <p>Полная коллекция цифрового видеоконтента</p>
            </div>
            <div className="feature-card">
              <div className="feature-icon">🎵</div>
              <h3>Музыкальные видео</h3>
              <p>Клипы и музыкальные выступления</p>
            </div>
            <div className="feature-card">
              <div className="feature-icon">📱</div>
              <h3>Мультиплатформенность</h3>
              <p>Доступ с любых устройств</p>
            </div>
            <div className="feature-card">
              <div className="feature-icon">💳</div>
              <h3>Гибкая система оплаты</h3>
              <p>Покупка и аренда контента</p>
            </div>
          </div>

          <div className="api-section">
            <h2>Тестирование API</h2>
            <div className="button-group">
              <button 
                className="api-button" 
                onClick={fetchContents}
                disabled={loading || apiStatus !== 'connected'}
              >
                {loading ? 'Загрузка...' : 'Загрузить контент'}
              </button>
              <button 
                className="api-button" 
                onClick={fetchGenres}
                disabled={loading || apiStatus !== 'connected'}
              >
                {loading ? 'Загрузка...' : 'Загрузить жанры'}
              </button>
              <a 
                href={`${API_URL}/swagger`} 
                target="_blank" 
                rel="noopener noreferrer"
                className="api-button link-button"
              >
                Открыть Swagger UI
              </a>
            </div>

            {contents.length > 0 && (
              <div className="results">
                <h3>Контент ({contents.length})</h3>
                <div className="content-list">
                  {contents.slice(0, 5).map((content) => (
                    <div key={content.contentId} className="content-item">
                      <h4>{content.title}</h4>
                      <p>{content.description || 'Описание отсутствует'}</p>
                      <span className="price">${content.basePrice || '0.00'}</span>
                    </div>
                  ))}
                </div>
              </div>
            )}

            {genres.length > 0 && (
              <div className="results">
                <h3>Жанры ({genres.length})</h3>
                <div className="genre-list">
                  {genres.map((genre) => (
                    <span key={genre.genreId} className="genre-tag">
                      {genre.name}
                    </span>
                  ))}
                </div>
              </div>
            )}
          </div>

          <footer className="footer">
            <p>Разработано с использованием ASP.NET Core 8.0 и React</p>
            <p>База данных: PostgreSQL</p>
          </footer>
        </div>
      </header>
    </div>
  );
}

export default App;









