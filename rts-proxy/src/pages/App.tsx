import Auth from '../Smart/Auth';
import Forecast from '../Smart/Forecast';
import State from '../Smart/State';

export const App = () => (
  <div>
    <Forecast />
    <State UF='sp' />
    <State UF='ac' />
    <State UF='to' />
    <Auth />
  </div>
);