Vue.component('k-layout', {
    template:
        `
        <v-app>
            <v-app-bar app color="light-green darken-1 pa-0" height=75px>

                <v-app-bar-nav-icon class="green darken-2 white--text" @click="drawler = !drawler"></v-app-bar-nav-icon>
                <v-toolbar-title>
                    <h3 class="font-weight-bold mt-3 pt-2 white--text">BlogPost App</h3>
                    <p class="white--text">{{pageTitle}}</p>
                </v-toolbar-title>
                <v-spacer></v-spacer>
                <v-btn class="green darken-2">
                    <span class="white--text">Sign In</span>
                    <v-icon right class="white--text">mdi-login</v-icon>
                </v-btn>
            </v-app-bar>

            <v-navigation-drawer v-model="drawler" app class="light-green darken-1">
                <v-container>
                    <v-row>
                        <v-col>
                            <v-list>
                                <v-list-item class="text-right">
                                    <v-list-item-content>
                                        <v-spacer></v-spacer>
                                        <v-col>
                                            <v-btn fab small @click="drawler = !drawler" class="green darken-2 white--text">
                                            <v-icon>mdi-close</v-icon>
                                        </v-btn>
                                        </v-col>
                                    </v-list-item-content>
                                </v-list-item>
                                <v-list-item v-for="link, i in links" :key="i">
                                    <v-list-item-content>
                                        <v-btn :href=link.url class="green darken-2 white--text">
                                            <v-col> 
                                                <v-icon>{{link.icon}}</v-icon>
                                            </v-col>                                 
                                            <v-col>
                                                {{link.text}}
                                            </v-col>
                                        </v-btn>
                                    </v-list-item-content>
                                </v-list-item>
                            </v-list>
                        </v-col>
                    </v-row>
                </v-container>
            </v-navigation-drawer>

            <v-main class="grey lighten-3" >
                <slot ></slot>
            </v-main>

            <v-footer></v-footer>
        </v-app>
`,
    data() {
        return {
            drawler: false,
            actualSite: 'Home page',
            links: [
                { icon: 'mdi-home', text: 'Home', url: window.location.origin + '/Home/Index' },
                { icon: 'mdi-post-outline', text: 'Blog Posts', url: window.location.origin + '/BlogPosts/Index' },
                { icon: 'mdi-account-group', text: 'Users', url: window.location.origin + '/Users/Index' },
                { icon: 'mdi-email', text: 'Contact', url: window.location.origin + '/Contact/Index' },
            ],

            
            

        }
    },
    props: ["pageTitle", "aktualHost"]
})

      