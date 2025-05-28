const API_URL = "https://rickandmortyapi.com/api";

export async function getRandomCharacters(count = 4) {
    const maxId = 826;
    const ids = [];

    while (ids.length < count) {
        const randomId = Math.floor(Math.random() * maxId) + 1;

        if (!ids.includes(randomId)) {
            ids.push(randomId);
        }
    }

    const response = await fetch(`${API_URL}/character/${ids.join(',')}`);
    const data = await response.json();

    return Array.isArray(data) ? data : [data];
}