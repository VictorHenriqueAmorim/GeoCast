import axios from 'axios';
import { fetchWeather } from './weatherService';

jest.mock('axios');

describe('fetchWeather', () => {
  it('fetches weather data for a given address', async () => {
    const mockData = {
      data: 'result123'
    };

    axios.get.mockResolvedValue(mockData);

    const address = 'address123';
    const response = await fetchWeather(address);

    expect(axios.get).toHaveBeenCalledWith(`https://localhost:44324/api/Weather/weather?address=${address}`);
    expect(response).toEqual(mockData);
  });
});
