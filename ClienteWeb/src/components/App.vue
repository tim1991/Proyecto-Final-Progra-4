<template>
    <div id="app">
        <component :is="layout">
            <router-view></router-view>
        </component>
    </div>
</template>

<script>
    import {
        misMixins
    } from "../mixins"
    const default_layout = "no-sidebar-layout"
    export default {
        mixins: [misMixins],
        name: 'App',
        components: {},
        mounted() {
        },
        computed: {
            layout() {
                return (this.$route.meta.layout || default_layout);
            }
        }
    }
</script>