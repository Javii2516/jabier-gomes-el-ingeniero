let episodePage = 1;

function fetchCharacterData() {
  fetch('https://rickandmortyapi.com/api/character/1')
    .then(response => response.json())
    .then(data => {
      const name = data.name;
      const image = data.image;
      const gender = data.gender;
      const status = data.status;
      const species = data.species;
      
      document.getElementById('character-name').textContent = name;
      document.getElementById('character-image').src = image;
      document.getElementById('character-details').textContent = `Gender: ${gender} | Status: ${status} | Species: ${species}`;
    })
    .catch(error => {
      console.log('Error fetching character data:', error);
    });
}

function fetchEpisodeData() {
  const episodeContainer = document.getElementById('episode-container');
  
  fetch(`https://rickandmortyapi.com/api/episode?page=${episodePage}`)
    .then(response => response.json())
    .then(data => {
      const episodes = data.results;
      
      episodes.forEach(episode => {
        const episodeCard = document.createElement('div');
        episodeCard.classList.add('card');
        
        const episodeName = document.createElement('h3');
        episodeName.textContent = episode.name;
        
        const episodeDetails = document.createElement('p');
        episodeDetails.textContent = `Episode: ${episode.episode}`;
        
        episodeCard.appendChild(episodeName);
        episodeCard.appendChild(episodeDetails);
        episodeContainer.appendChild(episodeCard);
      });
    })
    .catch(error => {
      console.log('Error fetching episode data:', error);
    });
}

function loadRickAndMortyEpisodes() {
  const episodeContainer = document.getElementById('episode-container');
  episodeContainer.innerHTML = ''; // Limpiar el contenedor de episodios antes de cargar nuevos
  
  episodePage = 1; // Reiniciar la página de episodios
  
  fetchEpisodeData();
}

function loadMoreEpisodes() {
  episodePage++; // Incrementar la página de episodios
  
  fetchEpisodeData();
}

function showModal() {
  const modal = document.getElementById('modal');
  const modalName = document.getElementById('modal-name');
  const modalDetails = document.getElementById('modal-details');
  const characterName = document.getElementById('character-name').textContent;
  
  modal.style.display = 'block';
  modalName.textContent = characterName;
  modalDetails.textContent = 'Additional details about ' + characterName;
}

function closeModal() {
  const modal = document.getElementById('modal');
  modal.style.display = 'none';
}

fetchCharacterData();
