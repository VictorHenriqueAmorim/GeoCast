import { render, screen } from '@testing-library/react';
import App from './App';

  test('renders the app with weather data', async () => {
      render(<App />);
      expect(screen.getByText('7-Day Weather Forecast')).toBeInTheDocument();
  });
