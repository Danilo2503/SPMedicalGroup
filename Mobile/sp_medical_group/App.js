import React from 'react';
import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';

import Login from './src/screens/login';
import Home from './src/screens/home';
import Consulta from './src/screens/consultas';

const AuthStack = createStackNavigator();

export default function Stack(){
  return(
    <NavigationContainer>
      <AuthStack.Navigator
        headerMode = 'none'
      >
        <AuthStack.Screen name = 'Login' component={Login} />
        <AuthStack.Screen name = 'Home' component={Home} />
        <AuthStack.Screen name = 'Consulta' component={Consulta}/>
      </AuthStack.Navigator>
    </NavigationContainer>
  )
}