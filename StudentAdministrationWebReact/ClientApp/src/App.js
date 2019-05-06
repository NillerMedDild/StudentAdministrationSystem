import React from 'react';
import { Route } from 'react-router';
import Layout from './Components/Layout';
import Home from './Pages/Home';
import Schools from './Pages/Schools';
import Students from './Pages/Students';

export default () => (
  <Layout>
    <Route exact path='/' component={Home} />
    <Route path='/schools' component={Schools} />
    <Route path='/students' component={Students} />
  </Layout>
);
