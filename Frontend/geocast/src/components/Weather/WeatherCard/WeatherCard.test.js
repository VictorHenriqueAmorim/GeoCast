import React from 'react';
import { render, screen } from '@testing-library/react';
import WeatherCard from './WeatherCard';

describe('WeatherCard', () => {
  const mockForecast = {
    startTime: new Date().toISOString(),
    icon: 'test',
    shortForecast: 'asdas',
    name: 'test',
    temperature: 68,
    temperatureUnit: 'F',
    detailedForecast: 'asdasdasdasdasd'
  };

  it('renders WeatherCard with forecast data', () => {
    render(<WeatherCard forecast={mockForecast} />);

    expect(screen.getByRole('img')).toHaveAttribute('src', mockForecast.icon);
    expect(screen.getByRole('img')).toHaveAttribute('alt', mockForecast.shortForecast);
    expect(screen.getByText(mockForecast.name)).toBeInTheDocument();
    expect(screen.getByText(`${mockForecast.temperature} ${mockForecast.temperatureUnit}`)).toBeInTheDocument();
    expect(screen.getByText(mockForecast.shortForecast)).toBeInTheDocument();
    expect(screen.getByText(mockForecast.detailedForecast)).toBeInTheDocument();
  });
});
