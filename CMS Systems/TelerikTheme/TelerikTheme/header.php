<!DOCTYPE html>
<html lang="en">
<head>
	<title><?php bloginfo('name');?><?php wp_title();?></title>
	<meta charset="<?php bloginfo( 'charset' ); ?>"/>
	<meta name="description" content="Telerik blue-green theme">
	<meta name="author" content="Telerik Academy student">
	<meta name="viewport" content="width=device-width"/> 
	<link rel="icon" href="<?php echo get_template_directory_uri();?>/images/icon_telerik.png" />
	<link rel="shortcut icon" href="<?php echo get_template_directory_uri();?>/images/icon_telerik.png" />
	<link type="text/css" rel="stylesheet" href="<?php bloginfo(stylesheet_url);?>"/>
</head>
<body>
<div id="site-wrap">

<!-- HEader -->
	<div id="header">
		<!--TOP MENU-->
		<div id="top-menu" class="clear-after">
			<?php wp_nav_menu(array(
				'theme_location' => 'top-menu',
				'container' => '',
				'items_wrap' => '<ul>%3$s</ul>',
			))
			?>
			<?php get_search_form(); ?>
		</div>
		<!--TOP MENU-->
		<h1 id="logo">
			<a href="<?php echo esc_url( home_url( '/' ) ); ?>" title="<?php echo esc_attr( get_bloginfo( 'name', 'display' ) ); ?>" rel="home">
				<?php bloginfo( 'name' ); ?>
			</a>
		</h1>
		<div id="title">
			<?php bloginfo( 'description' ); ?>
		</div>
		<!--NAVIGATION-->
		<div id="nav" class="clear-after">
			<?php 
				wp_nav_menu(array(
					'theme_location' => 'navigation',
					'container' => '',
					'items_wrap' => '<ul>%3$s</ul>',
				))
			?>
		</div>
		<!--NAVIGATION-->
	</div>