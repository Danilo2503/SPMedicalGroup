import React, { Component } from 'react';
import { Image, StyleSheet, View } from 'react-native';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';

import Login from './login';
import Consultas from './consultas';
import Profile from './profile';

const bottomTab = createBottomTabNavigator();

export default class Main extends Component {

  render(){
    return (
      <View style={styles.main}>
        <bottomTab.Navigator
        initialRouteName= 'Consultas'
        
        tabBarOptions={{
            showLabel: false,
            showIcon: true,
            activeBackgroundColor: '#ADD8E6',
            inactiveBackgroundColor: '#ADD8E6',
            activeTintColor: '#FFF',
            style: { height : 50 }
        }}
        screenOptions={({ route }) => ({

            tabBarIcon: () => {
            if (route.name === 'Consultas') {
                return(
                <Image
                    source={require('../../assets/img/calendario.png')}
                    style={styles.tabBarIcon}
                />
                )
            }else{
              return(
                <Image 
                    source={require('../../assets/img/avatar-profile.png')}
                    style={styles.tabBarIcon}
                />
                )
            }
            }
        }) }
        >
            <bottomTab.Screen name="Consultas" component={Consultas} />
            <bottomTab.Screen name="Perfil" component={Profile} />
        </bottomTab.Navigator>
      </View>
    );
  }
}

const styles = StyleSheet.create({

  main: {
    flex: 1,
    backgroundColor: '#FFFFFF'
  },

  tabBarIcon: {
    width: 22,
    height: 22
  }

});