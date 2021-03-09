import React from 'react';
import { SafeAreaView, View, Text, Image, StyleSheet } from 'react-native';
import Cabecalho from './views/components/Cabecalho';

const App = () => {
    return (
        <SafeAreaView style={styles.container}>
            <Cabecalho></Cabecalho>
        </SafeAreaView>

    )
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        backgroundColor: '#3b0099',
    },
})
export default App;